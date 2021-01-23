        public int UpdateFrom18() {
            // remove the CarouselContentPart part cleanly
            ContentDefinitionManager.DeletePartDefinition(typeof (CarouselContentPart).Name);
    enter code here
            // re-add the CarouselContentPart again
            // NOTE: Change this bit to add include whatever you have created in your previous 17 migrations such as setting up the part and adding fields
            ContentDefinitionManager.AlterPartDefinition(typeof (CarouselContentPart).Name,
                cfg = > cfg
                .Attachable()
                .WithDescription("Some kind of description, etc"));
            return 4;
        }
