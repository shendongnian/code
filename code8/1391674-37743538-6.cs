    public string getText(Point object) {
        if (object.IsAssignableFrom(RightTriangle)) {
            return "Side A: "+((RightTriangle)object).sideA.toString();
        }
        string retString = "";
        if (object.IsAssignableFrom(Circle)){
            retString += "Radius: "+((Circle)object).radius.toString();
        }
        if (object.IsAssignableFrom(Cone)){
            retString += "Height: "+((Cone)object).height.toString();
        }    
    }
