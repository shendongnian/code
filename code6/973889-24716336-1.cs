        private async void _load()
        {
            string[] n = { " ", "  ", "   ", "    ", "     ", "      ", "       ", "        ", "         ", "          " };
            while (true)
            {
                l1.Text = "• • • • •";
                await Task.Delay(500);
                for(int i=0; i<10; i++)
                {
                    if (i < 4)
                    {
                        await Task.Delay(50);
                        l1.Text = "• • • •" + n[i] + "•";
                    }
                    else if(i >4 && i< 7)
                    {
                        await Task.Delay(100);
                        l1.Text = "• • • •" + n[i] + "•";
                    }
                    else
                    {
                        await Task.Delay(180);
                        l1.Text = "• • • •" + n[i] + "•";
                    }
                }
            }
        }
