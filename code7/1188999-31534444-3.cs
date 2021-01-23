    {
        public MailResult GetMailResult(mail)
        {
            _objectStructure.Visit(mail)
        }
        ObjectStructure _objectStructure= new ObjectStructure();
        constructor() {
             _objectStructure.Attach(new AcronisBackupVisitor());
             _objectStructure.Attach(new ...)
        }
    }
    class AcronisBackupVisitor: Visitor {
        public override void Visit(HereComesAConcreteTypeDerivedFromMail concreteElement)
        {
             // do stuff
        }
        public override void Visit(HereComesAConcreteTypeDerivedFromMailOther concreteElement)
        {
            //don't do stuff. We are not in the right concrete mail type
        }
    }
