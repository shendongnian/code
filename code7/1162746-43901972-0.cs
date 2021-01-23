    class MyHandlingLogic : IDisposable
     Target { get; set; }
     RegistrationDelegate { get; set; }
     OnTargetSet(target) { 
       this.RegistrationDelegate = ...; // some code utilizing all properties set
       target.TargetEvent += this.RegistrationDelegate; 
     }
     Dispose() { target.TargetEvent -= this.RegistrationDelegate; }
    }
