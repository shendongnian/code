        float x = 0f;
        float y = 0f;
        float z = 0f;
        try
        {
             x = float.Parse(words[0], System.Globalization.CultureInfo.InvariantCulture);
             y = float.Parse(words[1], System.Globalization.CultureInfo.InvariantCulture);
             z = float.Parse(words[1], System.Globalization.CultureInfo.InvariantCulture);
        }
        catch (Exception e)
        {
            player.SendClientMessage(Color.DarkOrange, "Os valores de x,y e z não foram inseridos de forma correcta, apenas podes usar numeros");
            player.SendClientMessage(Color.DarkOrange, "Ex: /mudarspawn3 6321.6 , 96321.38 , 66322.2 ou /mudarspawn3 6321.6 96321.38 66322.2");
        }
        MSGameMysql.mudarspawn1(x, y, z);
        player.SendClientMessage(Color.AliceBlue, "Acabaste de mudar o spawn 1 para: x='" + x + "' y='" + y + "' z='" + z + "'");
