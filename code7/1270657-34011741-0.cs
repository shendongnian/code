    private Form1 parent
    public frmOptions(Form1 formRef)
            {
    
                InitializeComponent();
    
                // Sets the value of the Numeric UpDowns (boiteNbLignes & boiteNbColonnes
    
                // nbLignesDansTableauDeJeu & nbColonnesDansTableauDeJeu are the two integers I need to modify.
    
                boiteNbLignes.Value = frmJeu.nbLignesDansTableauDeJeu;
                boiteNbColonnes.Value = frmJeu.nbColonnesDansTableauDeJeu;
                parent = formRef;
    
            }
