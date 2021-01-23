    using System.ComponentModel.DataAnnotations;
    namespace Theater
    {
        public class Room
        {
            [DatabaseGenerated(DatabaseGeneratedOption.Identity)] // only if your primary key is auto-generated/identity column
            [Key]
            public int RoomId { get; set; }
        }
    }
