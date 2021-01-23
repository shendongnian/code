        private void lbCat_SelectedIndexChanged(object sender, EventArgs e)
            {
                if (!mIsLoaded) {
                     return;
                }
                //FAMILIE LISTBOX VULLEN ADHV GEKOZEN CATEGORIE
                queryCategorie = lbCat.Text.Remove(1);
                Console.WriteLine("~~~~GEKOZEN CATEGORIE: " + queryCategorie + ". Tijd: " + DateTime.Now.Ticks.ToString().Remove(0, 14));
                lbFamVullen();
            }
