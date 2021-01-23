    @{
    Mcrf.Profiles.ViewModels.McrfProfileDetailViewModel part =   Model.ProfileDetail;
    Style.Include("profile-styles.css?v=1.0").AtHead();
    Style.Include("bootstrap.css?v=1.0").AtHead();
    }
    @if (Model != null && part.ProfileDetail != null)
    {
    <div>
        <div >
            <div class="profileImgDiv">
                @if (Model != null && part != null)
                {
                    if (part.ProfileDetail.ProfileImage == null)
                    {
                        <img class="profile-img" src="~/Modules/Mcrf.Profiles/Content/Images/noProfilePictureImage.jpg" />
                    }
                    else
                    {
                        <img class="profile-img" src="@Url.Content(part.ProfileDetail.ProfileImage)" />
                    }
                }
            </div>
