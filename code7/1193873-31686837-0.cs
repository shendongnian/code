    set
    {
        if (this.operationLog != value)
        {
            this.operationLog = value;
            System.ComponentModel.PropertyChangedEventHandler handler = this.PropertyChanged;
            if (handler != null)
            {
                System.Action a  = () => handler(this, new PropertyChangedEventArgs("OperationLog"));
                System.Windows.Forms.Form.ActiveForm.Invoke(a);
            }
        }
    }
