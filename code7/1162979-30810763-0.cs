    WSHttpBinding binding = new WSHttpBinding();
    
    binding.Security.Mode = SecurityMode.Message;
    binding.Security.Message.EstablishSecurityContext = false;
    binding.Security.Message.NegotiateServiceCredential = false;
