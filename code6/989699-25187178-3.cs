    public static Type SelectFor(PersonType type)
        {
            switch (type)
            {
                case PersonType.Student:
                    return typeof(Student);
                case PersonType.Teacher:
                    return typeof(Teacher);
                default:
                    throw new Exception();
            }
        }
