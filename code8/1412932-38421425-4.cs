    public interface IFormOpener
    {
        void ShowModelessForm<TForm>() where TForm : Form;
        DialogResult ShowModalForm<TForm>() where TForm : Form;
    }
    
    public class FormOpener : IFormOpener
    {
        private readonly Container container;
        private readonly Dictionary<Type, Form> openedForms;
    
        public FormOpener(Container container)
        {
            this.container = container;
            this.openedForms = new Dictionary<Type, Form>();
        }
    
        public void ShowModelessForm<TForm>() where TForm : Form
        {
            Form form;
            if (this.openedForms.ContainsKey(typeof(TForm)))
            {
                // a form can be held open in the background, somewhat like 
                // singleton behavior, and reopened/reshown this way
                // when a form is 'closed' using form.Hide()   
                form = this.openedForms[typeof(TForm)];
            }
            else
            {
                form = this.GetForm<TForm>();
                this.openedForms.Add(form.GetType(), form);
                // the form will be closed and disposed when form.Closed is called
                // Remove it from the cached instances so it can be recreated
                form.Closed += (s, e) => this.openedForms.Remove(form.GetType());
            }
    
            form.Show();
        }
    
        public DialogResult ShowModalForm<TForm>() where TForm : Form
        {
            using (var form = this.GetForm<TForm>())
            {
                return form.ShowDialog();
            }
        }
    
        private Form GetForm<TForm>() where TForm : Form
        {
            return this.container.GetInstance<TForm>();
        }
    }
