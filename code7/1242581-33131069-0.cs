        var response = "{blueplates :[{\"Appetizer\":26,\"Salad\":21,\"Soup\":\"SheCrab\",\"Entree\":6434,\"Side\":2303093,\"Desert\":0,\"Beverage\":\"Sweet Tea + SoCO\"}, {\"Appetizer\":27,\"Salad\":21,\"Soup\":\"Tomato Bisque\",\"Entree\":6434,\"Side\":2303093,\"Desert\":0,\"Beverage\":\"Lemonade + Rum\"}, {\"Appetizer\":28,\"Salad\":21,\"Soup\":\"Peanut\",\"Entree\":6434,\"Side\":2303093,\"Desert\":0,\"Beverage\":\"Ginger Ale + Whiskey\"}]}";
        JavaScriptSerializer deSerializedResponse = new JavaScriptSerializer();
        RootObject root = (RootObject)deSerializedResponse.Deserialize(response, typeof(RootObject));
        for (int i = 0; i < root.blueplates.Count; i++)
        {
            Console.WriteLine(root.blueplates[i].Appetizer);
            Console.ReadLine();
        }
