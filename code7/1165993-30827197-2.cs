     private void GetHash()
        {
            bool hasValue1 =  string.IsNullOrWhiteSpace(txt_sel1.Text);
            bool hasValue2 =  string.IsNullOrWhiteSpace(txt_sel2.Text);
            bool hasValue3 =  string.IsNullOrWhiteSpace(txt_sel3.Text);
            bool hasValue4 =  string.IsNullOrWhiteSpace(txt_sel4.Text);
            bool hasValue5 =  string.IsNullOrWhiteSpace(txt_sel5.Text);
            if (hasValue1 && (hasValue2 || hasValue3 || hasValue4 || hasValue5))
            {
                txt_sel1.Text = txt_selectedText.Text;
                return;
            }
            else if (hasValue2 && (!hasValue1 ||hasValue3 || hasValue4 || hasValue5 ))
            {                
                    txt_sel2.Text = txt_selectedText.Text;
                    return;
            }
            else if (hasValue3 && (!hasValue1 || !hasValue2 || hasValue4 || hasValue5 ))
            {               
                    txt_sel3.Text = txt_selectedText.Text;
                    return;                
            }
            else if (hasValue4 && (!hasValue1 || !hasValue2 || !hasValue3 || hasValue5 ))
            {
                    txt_sel4.Text = txt_selectedText.Text;
                    return;
            }
            else if (hasValue5 && (!hasValue1 || !hasValue2 || !hasValue3 || !hasValue4 ))
            {
                txt_sel5.Text = txt_selectedText.Text;
                return;
            }
            else
            {
                CompareHash();
            }
            
        }
