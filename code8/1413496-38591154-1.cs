    public void RenderText(TextRenderInfo renderInfo)
    {
        foreach (TextRenderInfo info in renderInfo.GetCharacterRenderInfos())
        {
            textextractionstrategy.RenderText(info);
        }
    }
