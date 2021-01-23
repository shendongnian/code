        private void GetHyperlink()
        {
            Microsoft.Office.Interop.PowerPoint.Application objApp = new Microsoft.Office.Interop.PowerPoint.Application();
            objApp.Visible = Microsoft.Office.Core.MsoTriState.msoTrue;
            Presentations objPresSet = objApp.Presentations;
            Presentation p = objPresSet.Open("C:\test.ppt");
            Slide slide = p.Slides[1];
            // or Slide slide = objApp.ActiveWindow.View.Slide;
            for (int i = 1; i <= slide.Shapes.Count; i++)
            {
                //If the hyperlink address is filled then display it in MessageBox
                if (slide.Shapes[i].ActionSettings[PpMouseActivation.ppMouseClick].Hyperlink.Address != null)
                    MessageBox.Show(slide.Shapes[i].ActionSettings[PpMouseActivation.ppMouseClick].Hyperlink.Address);
            }
        }
