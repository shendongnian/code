            var fields = typeof(MainWindow).GetFields(BindingFlags.Instance | BindingFlags.NonPublic);
            foreach (FieldInfo FI in fields)
            {
                if (FI.FieldType == typeof(TextBox))
                {
                    TextBox value = FI.GetValue(this) as TextBox;
                    Console.WriteLine(FI.Name + ":" + value.Text);
                }
            }
