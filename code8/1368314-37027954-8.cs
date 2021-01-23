            if(!string.IsNullOrWhiteSpace(args.NewTextValue)) {
                int  result;
                string[] splitValue = args.NewTextValue.Split(new [] { ":" }, StringSplitOptions.RemoveEmptyEntries);
                foreach(string value in splitValue) {
                    if(value.Length > 2) {
                        ((Entry)sender).Text = args.NewTextValue.Remove(args.NewTextValue.Length - 1);
                        return;
                    }
                    bool isValid = int.TryParse(args.NewTextValue, out result);
                    if(!isValid) {
                        ((Entry)sender).Text = args.NewTextValue.Remove(args.NewTextValue.Length - 1);
                        return;
                    }
                }
                ((Entry)sender).Text = args.NewTextValue;
            }
