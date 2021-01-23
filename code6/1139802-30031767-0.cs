    static public decimal ToDecimal(this string str){
       decimal dec;
       if (decimal.TryParse(str, out dec))
       {
          return dec;
       }
       else
       {
          MessageBox.Show(str);
          return 0.0;
       }
    }
