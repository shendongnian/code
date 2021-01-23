    public partial class FormA:Form
    {
        ...
        public Label lbl_mnth;
        public FormA()
        {
              lbl_mnth = new Label();
              lbl_mnth.Name = "lbl_mnth";
              ...
              this.Controls.Add(lbl_mnth);
        }
    }
    public partial class Form1:Form
    {
        ...
        private void button1_Click(...)
        {
               FormA a = new FormA();
               a.Controls.OfType<Label>().ToList().Where(x=>x.Name == "lbl_mnth").FirstOrDefault().Text = "Blah Blah";
        }
    }
