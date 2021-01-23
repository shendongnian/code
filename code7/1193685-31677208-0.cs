    public str getImageAsBase64png()
    {
        Image   imgObj;
        BinData bd;
        str result;
        if (this.Image)
        {
            imgObj = new Image(this.Image);
            imgObj.saveType(ImageSaveType::PNG);
            bd = new BinData();
            bd.setData(imgObj.getData());
            result = bd.base64Encode();
        }
        else
        {
            result = "";
        }
        return result;
    }
