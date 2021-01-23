      private void LoopThroughControls()
      {
         foreach (var ctrl in this.Controls.OfType<GroupBox>().OrderBy(c => c.Name))
         {
            txtEntry.Text += (ctrl.Text + System.Environment.NewLine);
         }
      }
