    public List<IEnumerable<Rondin>> getPossibilites(IEnumerable<Rondin> rondins, int nbElements, double minimum, double maximum, int instance = 0, double longueur = 0)
    {
        if(instance == 0)
            timer = DateTime.Now;
        List<IEnumerable<Rondin>> liste = new List<IEnumerable<Rondin>>();
        //Get all distinct rondins that can fit into the maximal length
        foreach (Rondin r in rondins.Where(r => r.longueur < (maximum - longueur)).DistinctBy(r => r.longueur).OrderBy(r => r.longueur))
        {
            //Check the current length
            double longueur2 = longueur + r.longueur + traitScie;
            //If the current length is under the maximal length
            if (longueur2 < maximum)
            {
                //Get all the possibilities with all rondins except the current one, and add them to the list
                foreach (IEnumerable<Rondin> poss in getPossibilites(rondins.Where(rondin => rondin.id != r.id), nbElements - liste.Count, minimum, maximum, instance + 1, longueur2).Select(possibilite => possibilite.Concat(new Rondin[] { r })))
                {
                    liste.Add(poss);
                    if (liste.Count >= nbElements && nbElements > 0)
                        break;
                }
                //If this the current length in higher than the minimum, add it to the list
                if (longueur2 >= minimum)
                    liste.Add(new Rondin[] { r });
            }
            //If we have enough possibilities, we stop the research
            if (liste.Count >= nbElements && nbElements > 0)
                break;
            //If the research is taking too long, stop the research and return the list;
            if (DateTime.Now.Subtract(timer).TotalSeconds > 30)
                break;
        }
        return liste;
    }
