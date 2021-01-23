       enum TagIndexEnum { First, Second, Third };
        public static void SetSubTag(TagIndexEnum tagIndex, object[] array, object subTags)
    {
        switch (tagIndex)
        {
            case TagIndexEnum.First:
                subTags.FirstSubTag = array[0].Sub_Tag;
                subTags.FirstSubTagScore = array[0].AngerEmotion;
                break;
            case TagIndexEnum.Second:
                subTags.SecondSubTag = array[1].Sub_Tag;
                subTags.SecondSubTagScore = array[1].AngerEmotion;
                break;
            case TagIndexEnum.Third:
                subTags.ThirdSubTag = array[2].Sub_Tag;
                subTags.ThirdSubTagScore = array[2].AngerEmotion;
                break;
    
            default:
                throw new InvalidOperationException();
        }
    }
        // Using    
        var subTags = usertags.Anger.FirstMainTag.SubTags;
        // usertags.Anger.FirstMainTag.SubTags.FirstSubTag = Top3SubAngerFirst[0].Sub_Tag;
        // usertags.Anger.FirstMainTag.SubTags.FirstSubTagScore = Top3SubAngerFirst[0].AngerEmotion;
        SetSubTag(TagIndexEnum.First, Top3SubAngerFirst, subTags);
        
        // usertags.Anger.FirstMainTag.SubTags.SecondSubTag = Top3SubAngerFirst[1].Sub_Tag;
        // usertags.Anger.FirstMainTag.SubTags.SecondSubTagScore = Top3SubAngerFirst[1].AngerEmotion;
        SetSubTag(TagIndexEnum.Second, Top3SubAngerFirst, subTags);
        
        // usertags.Anger.FirstMainTag.SubTags.ThirdSubTag = Top3SubAngerFirst[2].Sub_Tag;
        // usertags.Anger.FirstMainTag.SubTags.ThirdSubTagScore = Top3SubAngerFirst[2].AngerEmotion;
        SetSubTag(TagIndexEnum.Third, Top3SubAngerFirst, subTags);
