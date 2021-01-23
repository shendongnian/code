    using System;
    
        namespace BusinessLogic
        {
            public interface IViewModelUIRule
            {
                event ViewModelValidationHandler ValidationDone;
            }
        
            public delegate void ViewModelValidationHandler(object sender, ViewModelUIValidationEventArgs e);
        
            public class ViewModelUIValidationEventArgs : EventArgs
            {
                public bool IsValid { get; set; }
        
                public ViewModelUIValidationEventArgs(bool valid) { IsValid = valid; }
            }
        }
