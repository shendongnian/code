    {
        public MailResult GetMailResult(mail)
        {
            _visitor.visit(mail)
        }
        Visitor _visitor = new Visitor();
        constructor() {
             _visitor.accept(new AcronisBackupVisitor());
             _visitor.accept(new ...)
        }
    }
    class AcronisBackupVisitor {
        public override void VisitorAcronisBackup(HereComesAConcreteTypeDerivedFromMail concreteElement)
        {
             // do stuff
        }
        public override void Visit...(HereComesAConcreteTypeDerivedFromMailOther concreteElement)
        {
            //don't do stuff. We are not in the right concrete mail type
        }
    }
