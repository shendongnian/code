       public class Paciente
        {
            public int id;
            public string nome;
            public int idade;
            public string morada;
            public string contato;
            public string email;
            public Array intervencoes;
            
        }
    List<Paciente> pacientes = new List<Paciente>();
             pacientes.Add(new Paciente { id = 1, nome = "amir", idade = 121, morada = "moradatest1", contato = "contatotest1", email = "emailtext1" });
             pacientes.Add(new Paciente { id = 2, nome = "amir2", idade = 123, morada = "moradatest2", contato = "contatotest2", email = "emailtext2" });
             pacientes.Add(new Paciente { id = 3, nome = "amir3", idade = 123, morada = "moradatest3", contato = "contatotest3", email = "emailtext3" });
            
             IEnumerable<Paciente> selectedPatient = from pac in pacientes
                                        where pac.id == 1
                                        select pac;
             foreach (var item in selectedPatient)
             {
                 Console.WriteLine("{0},{1},{2},{3},{4}", item.id, item.nome, item.idade, item.morada, item.contato,item.email);
                                  
             }
             Console.ReadLine();
