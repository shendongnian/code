         if (txtBox1.Text != "")
                {
                    char last_char = txtBox1.Text[txtBox1.Text.Length - 1];
                    switch (last_char)
                    {
                        case '+':
                            ViewState["Operation"] = "+";
                            txtBox1.Text.Remove(txtBox1.Text.Length - 1);
                            break;
                        case '-':
                            ViewState["Operation"] = "-";
                            txtBox1.Text.Remove(txtBox1.Text.Length - 1);
                            break;
                        // do the same for all operators
                        default:
    
                            break;
                    }
                }
