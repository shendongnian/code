    foreach (DataContract dc in propRespone2.GetType()
                .GetFields(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic)
                .Where(m => m.GetCustomAttributes(typeof(DataContract), false).Length > 0)
                .SelectMany(m => m.GetCustomAttributes(false).OfType<DataContract>()).ToArray())
    {
    System.Windows.Forms.MessageBox.Show(dc.Name);
    }
