string[] playlist = System.IO.File.ReadAllLines("I://LDSS Mix.txt");
for (int i = 0; i < playlist.Length; i++)
            {
    listBox1.Items.Add(playlist[i]);
}
