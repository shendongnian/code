    string str="";
            public string textContent
            {
                set { if (value != null) richtextbox.Document.SetText(Windows.UI.Text.TextSetOptions.None, value); else richtextbox.Document.SetText(Windows.UI.Text.TextSetOptions.None, ""); }
                get { richtextbox .Document.GetText(Windows.UI.Text.TextGetOptions.AdjustCrlf, out str); return str; }
    
            }
