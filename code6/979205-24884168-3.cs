                //tags check
                if (slide.Shapes[i].Tags.Count > 0 && slide.Shapes[i].Tags["MyPic"]!=null && slide.Shapes[i].ActionSettings[PpMouseActivation.ppMouseClick].Hyperlink.Address != null)
                    MessageBox.Show(slide.Shapes[i].ActionSettings[PpMouseActivation.ppMouseClick].Hyperlink.Address);
                //or
                //name check
                if (slide.Shapes[i].Name.Equals("MyPic", StringComparison.InvariantCultureIgnoreCase) && slide.Shapes[i].ActionSettings[PpMouseActivation.ppMouseClick].Hyperlink.Address != null)
                    MessageBox.Show(slide.Shapes[i].ActionSettings[PpMouseActivation.ppMouseClick].Hyperlink.Address);
