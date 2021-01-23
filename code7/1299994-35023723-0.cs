     catch (Exception ex)
            {
                String mesg;
                int Reg = 0;
                mesg = ex.ToString();
                RES = 4; //Asigna 4 a Res en caso de algún error durante la operación
                //Insertar Registro en Bitácora
                String MsgFinal = "Error de Sistema Mensaje de Error: " + mesg;
                Reg = CrearBitacora("System", pagWeb, RES, MsgFinal); // <---- This line!!!
                //FIN Insertar Registro en Bitácora
            }
