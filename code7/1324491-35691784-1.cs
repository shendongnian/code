          foreach (Control  item in myform.Controls)
            {
                if (item is Label)
                {
                  var  lbl = (Label)item;
                  bool labelIsEmpty = false;
                  try
                  {
                      lbl = (Label)item;
                      labelIsEmpty = (lbl != null && lbl.Text == string.Empty && lbll.Text!="Label");
                  }
                  catch 
                  { 
                  //Throw error message
                  }
                  if (labelIsEmpty)
                  {
                      lbl.Text = "Not Specified";
                  }
                }
            }
