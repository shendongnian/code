    public void Save(string fileName)
    {
         var content = new StringBuilder();
         foreach(var cartItem in shoppingCart)
         {
              content.AppendFormat("Item: {0}{1}", cartItem.Name, Environment.NewLine);
         }
         System.IO.File.WriteAllText(@"C:\Users\barry\Desktop\GG\pewpew\receipt.txt", contents.ToString());
    }
