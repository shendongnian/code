    public class SelectAllAction : TriggerAction<TextBox>
    {
        protected override void Invoke(object parameter)
        {
            if(this.AssociatedObject != null)
            {
                this.AssociatedObject.SelectAll();
            }
        }
    }
