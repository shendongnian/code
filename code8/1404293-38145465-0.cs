            int a = 1;
            int b = 2;
            int c = 3;
                bool state = streamBox.Checked;
                while (state == true)
                {
                System.Console.WriteLine("{0},{1},{2}", a,b,c);
                await Task.Delay(10);
            }
        }
