    public void Foo()
    {
        DoWork(chbx_Ext_tit1.Checked, txt_ext_tit_nom1.Text, txt_ext_tit_num1.Text);
        DoWork(chbx_Ext_tit2.Checked, txt_ext_tit_nom2.Text, txt_ext_tit_num2.Text);
    }
    public void DoWork(bool isChecked, string text1, string text2)
    {
        if (isChecked)
        {
            FileStream fs1 = new FileStream(@"c:\LigueStats\data\TXT\Nom_joueur.txt", FileMode.Create);
            StreamWriter fichier1 = new StreamWriter(fs1);
            fichier1.Write(text1);
            fichier1.Close();
            //Numéro
            FileStream fs2 = new FileStream(@"c:\LigueStats\data\TXT\Num_joueur.txt", FileMode.Create);
            StreamWriter fichier2 = new StreamWriter(fs2);
            fichier2.Write(text2);
            fichier2.Close();
        }
    }
