    [Serializable]
    public abstract class ControlDescriptor {
      public abstract void SetupControl(ControlCollection controls);
    
    }
    [Serializable]
    public class LabelDescriptor : ControlDescriptor {
      public string Text { get; set; }
      public override void SetupControl(ControlCollection controls) {
        var cotrol = controls.OfType<Label>().First(c => c.ID == "lbl");
        cotrol.Visible = true;
        cotrol.Text = Text;
      }
    }
    [Serializable]
    public class CheckBoxDescriptor : ControlDescriptor {
      public string Text { get; set; }
      public override void SetupControl(ControlCollection controls) {
        var cotrol = controls.OfType<CheckBox>().First(c => c.ID == "chx");
        cotrol.Visible = true;
        cotrol.Text = Text;
      }
    }
