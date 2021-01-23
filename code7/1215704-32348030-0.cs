            Button btn = new Button();
            btn.Text = "+";
            btn.Attributes.Add("onclick", "javascript:return btnClick(" + e.Day.DayNumberText + ")");
            btn.Style.Add("cursor", "pointer");
            
            TextBox txt = new TextBox();
            txt.ID = e.Day.DayNumberText.ToString();
            txt.Attributes.Add("style", "display:none;");
            txt.Attributes.Add("onclick", "JavaScript:void(window.open('Test/Default.aspx'))");
            e.Cell.Controls.Add(txt);
            e.Cell.Controls.Add(btn);
        }
