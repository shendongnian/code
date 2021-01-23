    public List<EA.Element> findElementsByStereotype(string stereotype) {
        List<EA.Element> result = new List<EA.Element>();
        foreach (EA.Element element in repository.GetElementSet("select Object_ID " +
                 "from t_object where Stereotype='" + stereotype + "'", 2)) {
            result.Add(element);
        }
    }
