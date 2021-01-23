    public static void rat(Page x)
        {
            webform1 myForm = (webform1)x;
            foreach (Control c in myForm.Controls)
            {
                if (c.Name != "ctn" && !(c is Label))
                {
                    ((Label)c).Enabled = !((Label)c).Enabled);
                }
            }
        }
