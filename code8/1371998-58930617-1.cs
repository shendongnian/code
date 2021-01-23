         private void btnTek_Click(object sender, EventArgs e)
        {
            lvFiltered.Items.Clear();
            string[] sayilar = tbSayilar.Text.Split('\n');
            int[] array = new int[sayilar.Length];
            for (int i = 0; i < sayilar.Length; i++)
            {
                array[i] = int.Parse(sayilar[i]);
            }
            List<int> ayiklanmisSayilar = TekCiftAyir(array, "T");
            for (int i = 0; i < ayiklanmisSayilar.Count; i++)
            {
                lvFiltered.Items.Add(ayiklanmisSayilar[i].ToString());
            }
        }
        private void btnCift_Click(object sender, EventArgs e)
        {
            lvFiltered.Items.Clear();
            string[] sayilar = tbSayilar.Text.Split('\n');
            int[] array = new int[sayilar.Length];
            for (int i = 0; i < sayilar.Length; i++)
            {
                array[i] = int.Parse(sayilar[i]);
            }
            List<int> ayiklanmisSayilar = TekCiftAyir(array, "C");
            for (int i = 0; i < ayiklanmisSayilar.Count; i++)
            {
                lvFiltered.Items.Add(ayiklanmisSayilar[i].ToString());
            }
        }
        private List<int> TekCiftAyir(int[] array, string TC)
        {
            List<int> ayiklanmisSayilar = new List<int>();
            if (TC == "T")
            {
                for (int i = 0; i < array.Length; i++)
                {
                    if (array[i] % 2 == 1)
                    {
                        ayiklanmisSayilar.Add(array[i]);
                    }
                }
            }
            if (TC == "C")
            {
                for (int i = 0; i < array.Length; i++)
                {
                    if (array[i] % 2 == 0)
                    {
                        ayiklanmisSayilar.Add(array[i]);
                    }
                }
            }
            return ayiklanmisSayilar;
        }
    
        }
