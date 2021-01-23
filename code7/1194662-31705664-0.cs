            //Stream Reader to String[]
            StreamReader mc = new StreamReader(ac.Assets.Open("Menu_Code.txt"));
            StreamReader mt = new StreamReader(ac.Assets.Open("Menu_Text.txt"));
            string[] code = streamToArry(mc);
            string[] text = streamToArry(mt);
            //string[] code = File.ReadAllLines(@"JittersApp/Droid/Assets/Menu Code.txt");
            //string[] text = File.ReadAllLines(@"JittersApp/Droid/Assets/Menu Text.txt");
            int codemax = code.Length;
            int current = 0;
            int im = input.Length;
            string menu = "oder ";
            while (true)
            {
                if (current < codemax)
                {
                    if (current < im)
                    {
                        if (text.Contains(input[current]))
                        {
                            int num = 0;
                            while (true)
                            {
                                string item = input[current];
                                if (text[num + 1].Equals(item))
                                {
                                    menu = menu + code[num + 1] + " ";
                                    break;
                                }
                                else
                                {
                                    num++;
                                }
                            }
                        }
                        current++;
                    }
                    else
                    {
                        break;
                    }
                }
                else
                {
                    break;
                }
            }
            
            new AlertDialog.Builder(ac)
            .SetMessage(menu)
            .Show();
            return menu;
        }
