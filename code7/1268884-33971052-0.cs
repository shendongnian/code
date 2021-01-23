        Element e = doc.GetElement(pickedRef);
        Element e = doc.GetElement(pickedRef);
        ElementType type = doc.GetElement(e.GetTypeId()) as ElementType;
        //to get height of section
        Parameter h = type.LookupParameter("h");
        double height = h.AsDouble();
        //to get width of section
        Parameter b = type.LookupParameter("b");
        double width = b.AsDouble();
        //and so on...
