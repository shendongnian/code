    namespace Tales_Of_Myroth
    {
        public class TalesOfMyroth
        {
            static void Main(string[] args)
            {
                Tales();
            }
    
            private Jogador _jogador;
    
            public void Tales()
            {
                _jogador = new Jogador();
    
                _jogador.VidaAtual = 50;
                _jogador.VidaMaxima = 50;
                _jogador.Ouro = 0;
    
                Console.WriteLine("Vida: " + _jogador.VidaAtual);
    
            }
        }
    }
