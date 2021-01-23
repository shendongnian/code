        switch (propertyName)
        {
            case "A":
                //Change the Private b instead of B so it won't call SomeAction twice.
                b = A + 1;
                SomeAction();
                break;
            case "B":
                SomeAction();
                break;
        }
