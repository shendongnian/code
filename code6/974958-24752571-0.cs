    private bool UserWeighsBetween55and100(IEnumerable<XElement> paramsList) {
            bool result = false;
            foreach (XElement parameter in paramsList) {
                if (parameter.Attribute("name").Value == "Weight") {
                    if ((parameter.Attribute("value").Value)!=null) {
                        if ((Convert.ToDouble(parameter.Attribute("value").Value) > 55) && (Convert.ToDouble(parameter.Attribute("value").Value) < 100)) {
                        return true;
                        }
                    }
                }
            }
            return result;
        }
