            foreach (var x in ports)
            {
                var addMe = new ComboBoxItem { Content = x };
                cb.Add(addMe);
                var p = new System.IO.Ports.SerialPort(x);
                if (p.IsOpen)
                {
                    addMe.FontWeight = FontWeights.Bold;
                }
            }
