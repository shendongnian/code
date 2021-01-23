    public Type ElegirScript()
        {
            switch ((int)tipoEdificio)  // enum
            {
                case 0:
                    return typeof(Edificios);  // a class/script not instance
                case 1:
                    return typeof(PlantaEnergia);  // a class/script not instance
                default:
                    return null;//Or throw exception here
            }
        }
