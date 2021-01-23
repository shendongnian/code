    abstract class Artifact{
         internal abstract void Visit(ArtifactVisitor visitor);
    }
    class Topic : Artifact{
         internal override void Visit(ArtifactVisitor visitor)
         {
            visitor.Visit(this);
         }
    }
    
    class ArtifactVisitor{
        internal virtual void Visit(Artifact artifact)
        {
            artifact.Visit(this);
        }
        protected virtual void Visit(Topic topic)
        {
        }
    }
    class SomeSpecificTopicVisitor : ArtifactVisitor
    {
         protected override void Visit(Topic topic)
         {
             //do something with topics
         }     
    }
