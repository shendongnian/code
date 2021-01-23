    public static Dog ConvertTo(this Animal animal)
    {
        Dog concreteAnimal;
        if (animal.Name == "tom")
        {
            concreteAnimal = new Tiger(); // compiler error at this line
        }
        return concreteAnimal;
    }
