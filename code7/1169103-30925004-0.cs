    var query = from i in items
                select new QuestaoMontaProva
                {
                    Id = 1,
                    IQuestaoId = 2,
                    IExercicioId = 2
                };
    public interface IQuestao
    {
        int Id { get; set; }
    }
    public interface IExercicio
    {
        int Id { get; set; }
    }
    public class QuestaoMontaProva : IQuestao, IExercicio
    {
        public int Id { get; set; }
        public int IQuestaoId { get; set; }
        public int IQuestao.Id
        {
            get
            {
                return IQuestaoId;
            }
            set
            {
                IQuestaoId = value;
            }
        }
        
        public int IExercicioId { get; set; }
        public int IExercicio.Id
        {
            get
            {
                return IExercicioId;
            }
            set
            {
                IExercicioId = value;
            }
        }
    }
