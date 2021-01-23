        private static void OnBoundPasswordChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
                    {
                        PasswordBox box = d as PasswordBox;
                        string strValue=GetBoundPassword(d);
        }
    
    public static string GetBoundPassword(DependencyObject dp)
                {
                    return (string)dp.GetValue(BoundPasswordProperty);
                }
