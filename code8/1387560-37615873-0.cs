    public override bool Equals(Object obj) {
        SampleSentence otherObject = obj as SampleSentence;
        if (otherObject == null) {
            return false;
        }
        return Text.Equals(otherObject.Text);
    }
