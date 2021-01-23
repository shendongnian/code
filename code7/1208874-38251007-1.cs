            public static List<string> GetText(string text, int width)
        {
            string[] palabras = text.Split(' ');
            StringBuilder sb1 = new StringBuilder();
            StringBuilder sb2 = new StringBuilder();
            int length = palabras.Length;
            List<string> resultado = new List<string>();
            for (int i = 0; i < length; i++)
            {
                sb1.AppendFormat("{0} ", palabras[i]);
                if (sb1.ToString().Length > width)
                {
                    resultado.Add(sb2.ToString());
                    sb1 = new StringBuilder();
                    sb2 = new StringBuilder();
                    sb1.AppendFormat("{0} ", palabras[i]);
                    sb2.AppendFormat("{0} ", palabras[i]);
                }
                else
                {
                    sb2.AppendFormat("{0} ", palabras[i]);
                }
            }
            resultado.Add(sb2.ToString());
            List<string> resultado2 = new List<string>();
            string temp;
            int index1, index2, salto;
            string target;
            int limite = resultado.Count;
            foreach (var item in resultado)
            {
                target = " ";
                temp = item.ToString().Trim();
                index1 = 0; index2 = 0; salto = 2;
                if (limite <= 1)
                {
                    resultado2.Add(temp);
                    break;
                }
                while (temp.Length <= width)
                {
                    if (temp.IndexOf(target, index2) < 0)
                    {
                        index1 = 0; index2 = 0;
                        target = target + " ";
                        salto++;
                    }
                    index1 = temp.IndexOf(target, index2);
                    temp = temp.Insert(temp.IndexOf(target, index2), " ");
                    index2 = index1 + salto;
                }
                limite--;
                resultado2.Add(temp);
            }
            return resultado2;
        }
