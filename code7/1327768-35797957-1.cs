    if (rb_wcf1.IsChecked == true && !string.IsNullOrEmpty(this.tb_weight.Text))
        {                
            int a = Int32.Parse(tb_weight.Text);
            b = (a * 1.03) / 1000;
            lbl_wll.Content = Math.Round(b, 2);
        }
