    [TemplatePart(Name = "PART_SomethingButton", Type = typeof(Button))]
    public class MyControl : Control{
         private Button _partSomethingButton;
    
        protected override void OnApplyTemplate(){    
              _partSomethingButton = GetTemplateChild("PART_SomethingButton") as Button;   
              base.OnApplyTemplate();
        }
    }
