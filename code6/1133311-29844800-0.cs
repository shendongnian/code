    protected void Button1_Click(object sender, EventArgs e)
            {int j=0;
                string s, revs = "";
                s = TextBox1.Text;
                for (int i = s.Length - 1; i >= 0; i--) //String Reverse
                {
                    revs += s[i].ToString();
                }
                if (revs == s) // Checking whether string is palindrome or not
                {
                    Response .Write ("String is Palindrome");
                }
                else
                {
                    Response.Write("String is not Palindrome ");
                    int reverse = 0;
                    int numb;
                    int n1;
                    int b = 0;
                    n1 = int.Parse(TextBox1.Text);
                    numb = int.Parse(TextBox1.Text);
                    while (numb > 0)
                    {
                        int rem = numb % 10;
                        reverse = (reverse * 10) + rem;
                        numb = numb / 10;
                        j++;
                    }
                    b = reverse + n1;
                    TextBox1.Text = b.ToString();
                 
                     Response.Write(j);
                   }
                }
