    StreamWriter archivo = new StreamWriter("D:\\MAXIMUM PC.csv", true);
            {
                archivo.WriteLine('"' + "usuario" + '"' + ";" + '"' + "Hora de entrada" + '"' + ";" + '"' + "Hora de salida" + '"' + ";" + '"' + "Tiempo" + '"' + ";" + '"' + "Pago" + '"');
                for (i = 0; i < rows; i++)
                {
                    //assign the first variable, in my case, DateTime data types
                    fechaHora = Convert.ToDateTime(clu.Rows[i].Cells[0].Value.ToString());
                    for (j = i + 1; j < rows; j++)
                    {
                        //assign the second variable
                        fechaActual = Convert.ToDateTime(clu.Rows[j].Cells[0].Value.ToString());
                        if (fechaHora.Date == fechaActual.Date)
                        {
                            //here i start the compare process
                            if (fechaHora.TimeOfDay != fechaActual.TimeOfDay)
                            {
                                tiempo = fechaActual.Subtract(fechaHora);
                                // if the dates are the same, but their time is different..
                                if (tiempo.TotalHours > 7 && fechaHora.TimeOfDay > fechaActual.TimeOfDay)
                                {
                                    //if the timespan between the times is over 7 hours and the first date is over the second....
                                    entrada = fechaHora;
                                    salida = fechaActual;
                                    pay = Convert.ToDouble(tiempo.TotalHours * hourPay);
                                    archivo.WriteLine(usuario + ";" + entrada + ";" + salida + ";" + tiempo.TotalHours + ";" + pay);
                                }
                                //if the timespan between the times is over 7 hours and the second date is over the fist....
                                else if (tiempo.TotalHours > 7 && fechaHora.TimeOfDay < fechaActual.TimeOfDay)
                                {
                                    entrada = fechaHora;
                                    salida = fechaActual;
                                    pay = Convert.ToDouble(tiempo.TotalHours * hourPay);
                                    archivo.WriteLine(usuario + ";" + entrada + ";" + salida + ";" + tiempo.TotalHours + ";" + pay);
                                }
                                //if the timespan between the times is under 2 hours and the first date is under or equal the second....
                                else if (tiempo.TotalHours < 2 && fechaHora.TimeOfDay <= fechaActual.TimeOfDay)
                                {
                                    error = fechaActual;
                                }
                            }
                        }
                    }
                }
            }
