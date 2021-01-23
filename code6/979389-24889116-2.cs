    public Actionresult SomeAction()
    {
        XmlDocument doc = new XmlDocument();
        doc.Load("C:\\Tasks.xml");
        var model = new XmlViewModel
        {
            Xml = doc.InnerXml();
        }
        return View(model);
    }
    [HttpPost]
    public Actionresult SomeAction(XmlViewModel model)
    {
        ...       
 
        return View(model);
    }
