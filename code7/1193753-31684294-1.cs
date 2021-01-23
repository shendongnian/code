    using System.ComponentModel.DataAnnotations;
    
    namespace WebInterface.Core.Enum
    {
        public class Transaction
        {
            /// <summary>
            /// Die Transaktionstypen
            /// </summary>
            public enum Type
            {
                [Display(Name = "Aufgeladen")]
                Charged = 0,
    
                [Display(Name = "Abgebucht")]
                Debited = 1,
    
                [Display(Name = "Karte Gesperrt")]
                CardBlocked = 2,
    
                [Display(Name = "Karte Eingerichtet")]
                CardEstablished = 3,
    
                [Display(Name = "Protokoll Fehler")]
                ProtocolError = 4,
    
                [Display(Name = "Paket Fehler")]
                PackageError = 5,
    
                [Display(Name = "Karte Storno")]
                CardCanceled = 6,
    
                [Display(Name = "Karte Gratisabgabe")]
                CardFree = 7
            }
    
        }
    }
